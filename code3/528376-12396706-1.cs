    using System;
    using System.Collections.Generic;
    using System.IO;
    
    namespace WordCount
    {
    	class MainClass
    	{
    		public static void Main (string[] args)
    		{
    			Console.WriteLine ("Counting words...");
    			DateTime start_at = DateTime.Now;
    
    			TrieNode root = new TrieNode (null, '?');
    
    			if (args.Length == 1) 
    			{
    				ReadInputFile (args[0], ref root);
    			} 
    			else 
    			{
    				for (int i = 0; i < 100; i++) {
    					ReadInputFile ("war-and-peace.txt", ref root);
    					ReadInputFile ("ulysees.txt", ref root);
    					ReadInputFile ("les-miserables.txt", ref root);
    					ReadInputFile ("the-republic.txt", ref root);
    				}
    			}
    
    			DateTime stop_at = DateTime.Now;
    			Console.WriteLine("Input data processed in {0} secs", new TimeSpan(stop_at.Ticks - start_at.Ticks).TotalSeconds);
    
    
    			Console.WriteLine ();
    			Console.WriteLine ("{0} words found", TrieNode.DISTINCT_WORD_COUNT);
    			Console.WriteLine ("{0} nodes created", TrieNode.NODE_COUNT);
    			Console.WriteLine ("{0} words counted", TrieNode.TOTAL_WORD_COUNT);
    			Console.WriteLine ();
    			Console.WriteLine ("Most commonly found words:");
    
    			List<TrieNode> top10_nodes = new List<TrieNode> { root, root, root, root, root, root, root, root, root, root };
    			root.GetTopCounts (ref top10_nodes);
    			top10_nodes.Reverse();
    			foreach (TrieNode node in top10_nodes) 
    			{
    				Console.WriteLine ("{0} - {1} times", node.ToString(), node.m_word_count);
    			}
    		}
    
    		private static void ReadInputFile (string path, ref TrieNode root_node)
    		{
    			using (FileStream fstream = new FileStream(path, FileMode.Open, FileAccess.Read)) 
    			{
    				using (StreamReader sreader = new StreamReader(fstream))
    				{
    					string line;
    					while ((line = sreader.ReadLine()) != null)
    					{
    						string[] chunks = line.Split(null);
    						foreach(string chunk in chunks)
    						{
    							root_node.AddWord(chunk.Trim());
    						}
    					}
    				}
    			}
    		}
    	}
    
    	class TrieNode : IComparable<TrieNode>
    	{
    		static public int NODE_COUNT = 0;
    		static public int DISTINCT_WORD_COUNT = 0;
    		static public int TOTAL_WORD_COUNT = 0;
    
    		static public int MAX_COUNT = 0;
    		static public TrieNode MAX_COUNT_NODE = null;
    
    		private char m_char;
    		public int m_word_count;
    		private TrieNode m_parent = null;
    		private Dictionary<char, TrieNode> m_children = null;
    
    		public TrieNode (TrieNode parent, char c)
    		{
    			m_char = c;
    			m_word_count = 0;
    			m_parent = parent;
    			m_children = new Dictionary<char, TrieNode>();
    			NODE_COUNT++;
    		}
    
    		public void AddWord (string word, int index = 0)
    		{
    			if (index < word.Length) 
    			{
    				char key = word[index];
    				if (char.IsLetter(key)) // should do that during parsing but we're just playing here! right?
    				{
    					if (!m_children.ContainsKey(key))
    					{
    						m_children.Add(key, new TrieNode(this, key));
    					}
    					m_children[key].AddWord(word, index+1);
    				}
    				else
    				{
    					// not a letter! retry with next char
    					AddWord(word, index + 1);
    				}
    			} 
    			else 
    			{
    				if (m_parent != null) // rempty words should never be counted
    				{
    					m_word_count++;
    					TOTAL_WORD_COUNT++;
    					if (m_word_count == 1) DISTINCT_WORD_COUNT++;
    					if (m_word_count > MAX_COUNT) 
    					{
    						MAX_COUNT = m_word_count;
    						MAX_COUNT_NODE = this;
    					}
    				}
    			}
    		}
    
    		public int GetCount (string word, int index = 0)
    		{
    			if (index < word.Length) 
    			{
    				char key = word[index];
    				if (!m_children.ContainsKey(key))
    				{
    					return -1;
    				}
    				return m_children[key].GetCount(word, index + 1);
    			} 
    			else 
    			{
    				return m_word_count;
    			}
    		}
    
    		public void GetTopCounts (ref List<TrieNode> most_counted)
    		{
    			if (m_word_count > most_counted[0].m_word_count) 
    			{
    				most_counted[0] = this;
    				most_counted.Sort();
    			} 
    			foreach (char key in m_children.Keys) 
    			{
    				m_children[key].GetTopCounts(ref most_counted);
    			}
    		}
    
    		public override string ToString ()
    		{
    			if (m_parent == null) return "";
    			else return m_parent.ToString() + m_char;
    		}
    
    		public int CompareTo(TrieNode other)
    		{
    			return this.m_word_count.CompareTo(other.m_word_count);
    		}
    	}
    }
