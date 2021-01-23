	using System;
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.Linq;
	using size_t = System.UInt32;
	
	public class LRParser
	{
		private string[] symbols;  // index => symbol
		private IDictionary<string, size_t> interned = new SortedDictionary<string, size_t>();  // symbol => index
		private int[/*state*/, /*lookahead*/] actions;  // If >= 0, represents new state after shift. If < 0, represents one's complement (i.e. ~x) of reduction rule.
	
		public LRParser(params KeyValuePair<string, string[]>[] grammar)
		{
			this.interned.Add(string.Empty, new size_t());
			foreach (var rule in grammar)
			{
				if (!this.interned.ContainsKey(rule.Key))
				{ this.interned.Add(rule.Key, (size_t)this.interned.Count); }
				foreach (var symbol in rule.Value)
				{
					if (!this.interned.ContainsKey(symbol))
					{ this.interned.Add(symbol, (size_t)this.interned.Count); }
				}
			}
			this.symbols = this.interned.ToArray().OrderBy(p => p.Value).Select(p => p.Key).ToArray();
			var syntax = Array.ConvertAll(grammar, r => new KeyValuePair<size_t, size_t[]>(this.interned[r.Key], Array.ConvertAll(r.Value, s => this.interned[s])));
			var nonterminals = Array.ConvertAll(this.symbols, s => new List<size_t>());
			for (size_t i = 0; i < syntax.Length; i++) { nonterminals[syntax[i].Key].Add(i); }
	
			var firsts = Array.ConvertAll(Enumerable.Range(0, this.symbols.Length).ToArray(), s => nonterminals[s].Count > 0 ? new HashSet<size_t>() : new HashSet<size_t>() { (size_t)s });
	
			int old;
			do
			{
				old = firsts.Select(l => l.Count).Sum();
				foreach (var rule in syntax)
				{
					foreach (var i in First(rule.Value, firsts))
					{ firsts[rule.Key].Add(i); }
				}
			} while (old < firsts.Select(l => l.Count).Sum());
	
			var actions = new Dictionary<int, IDictionary<size_t, IList<int>>>();
			var states = new Dictionary<HashSet<Item>, int>(HashSet<Item>.CreateSetComparer());
			var todo = new Stack<HashSet<Item>>();
			var root = new Item(0, 0, new size_t());
			todo.Push(new HashSet<Item>());
			Closure(root, todo.Peek(), firsts, syntax, nonterminals);
			states.Add(new HashSet<Item>(todo.Peek()), states.Count);
			while (todo.Count > 0)
			{
				var set = todo.Pop();
				var closure = new HashSet<Item>();
				foreach (var item in set)
				{ Closure(item, closure, firsts, syntax, nonterminals); }
				var grouped = Array.ConvertAll(this.symbols, _ => new HashSet<Item>());
				foreach (var item in closure)
				{
					if (item.Symbol >= syntax[item.Rule].Value.Length)
					{
						IDictionary<size_t, IList<int>> map;
						if (!actions.TryGetValue(states[set], out map))
						{ actions[states[set]] = map = new Dictionary<size_t, IList<int>>(); }
						IList<int> list;
						if (!map.TryGetValue(item.Lookahead, out list))
						{ map[item.Lookahead] = list = new List<int>(); }
						list.Add(~(int)item.Rule);
						continue;
					}
					var next = item;
					next.Symbol++;
					grouped[syntax[item.Rule].Value[item.Symbol]].Add(next);
				}
				for (size_t symbol = 0; symbol < grouped.Length; symbol++)
				{
					var g = new HashSet<Item>();
					foreach (var item in grouped[symbol])
					{ Closure(item, g, firsts, syntax, nonterminals); }
					if (g.Count > 0)
					{
						int state;
						if (!states.TryGetValue(g, out state))
						{
							state = states.Count;
							states.Add(g, state);
							todo.Push(g);
						}
	
						IDictionary<size_t, IList<int>> map;
						if (!actions.TryGetValue(states[set], out map))
						{ actions[states[set]] = map = new Dictionary<size_t, IList<int>>(); }
						IList<int> list;
						if (!map.TryGetValue(symbol, out list))
						{ map[symbol] = list = new List<int>(); }
	
						list.Add(state);
					}
				}
			}
	
			this.actions = new int[states.Count, this.symbols.Length];
			for (int i = 0; i < this.actions.GetLength(0); i++)
			{
				for (int j = 0; j < this.actions.GetLength(1); j++)
				{ this.actions[i, j] = int.MinValue; }
			}
			foreach (var p in actions)
			{
				foreach (var q in p.Value)
				{ this.actions[p.Key, q.Key] = q.Value.Single(); }
			}
	
			foreach (var state in states.OrderBy(p => p.Value))
			{
				Console.WriteLine("State {0}:", state.Value);
				foreach (var item in state.Key.OrderBy(i => i.Rule).ThenBy(i => i.Symbol).ThenBy(i => i.Lookahead))
				{
					Console.WriteLine(
						"\t{0}: {1} \xB7 {2} | {3} →  {0}",
						this.symbols[syntax[item.Rule].Key],
						string.Join(" ", syntax[item.Rule].Value.Take((int)item.Symbol).Select(s => this.symbols[s]).ToArray()),
						string.Join(" ", syntax[item.Rule].Value.Skip((int)item.Symbol).Select(s => this.symbols[s]).ToArray()),
						this.symbols[item.Lookahead] == string.Empty ? "\x04" : this.symbols[item.Lookahead],
						string.Join(
							", ",
							Array.ConvertAll(
								actions[state.Value][item.Symbol < syntax[item.Rule].Value.Length ? syntax[item.Rule].Value[item.Symbol] : item.Lookahead].ToArray(),
								a => a >= 0 ? string.Format("state {0}", a) : string.Format("{0} (rule {1})", this.symbols[syntax[~a].Key], ~a))));
				}
				Console.WriteLine();
			}
		}
	
		private static void Closure(Item item, HashSet<Item> closure /*output*/, HashSet<size_t>[] firsts, KeyValuePair<size_t, size_t[]>[] syntax, IList<size_t>[] nonterminals)
		{
			if (closure.Add(item) && item.Symbol >= syntax[item.Rule].Value.Length)
			{
				foreach (var r in nonterminals[syntax[item.Rule].Value[item.Symbol]])
				{
					foreach (var i in First(syntax[item.Rule].Value.Skip((int)(item.Symbol + 1)), firsts))
					{ Closure(new Item(r, 0, i == new size_t() ? item.Lookahead : i), closure, firsts, syntax, nonterminals); }
				}
			}
		}
	
		private struct Item : IEquatable<Item>
		{
			public size_t Rule;
			public size_t Symbol;
			public size_t Lookahead;
	
			public Item(size_t rule, size_t symbol, size_t lookahead)
			{
				this.Rule = rule;
				this.Symbol = symbol;
				this.Lookahead = lookahead;
			}
	
			public override bool Equals(object obj) { return obj is Item && this.Equals((Item)obj); }
	
			public bool Equals(Item other)
			{ return this.Rule == other.Rule && this.Symbol == other.Symbol && this.Lookahead == other.Lookahead; }
	
			public override int GetHashCode()
			{ return this.Rule.GetHashCode() ^ this.Symbol.GetHashCode() ^ this.Lookahead.GetHashCode(); }
		}
	
		private static IEnumerable<size_t> First(IEnumerable<size_t> symbols, IEnumerable<size_t>[] map)
		{
			foreach (var symbol in symbols)
			{
				bool epsilon = false;
				foreach (var s in map[symbol])
				{
					if (s == new size_t()) { epsilon = true; }
					else { yield return s; }
				}
				if (!epsilon) { yield break; }
			}
			yield return new size_t();
		}
	
		private static KeyValuePair<K, V> MakePair<K, V>(K k, V v) { return new KeyValuePair<K, V>(k, v); }
	
		private static void Main(string[] args)
		{
			var sw = Stopwatch.StartNew();
			var parser = new LRParser(
				MakePair("start", new string[] { "exps" }),
				MakePair("exps", new string[] { "exps", "exp" }),
				MakePair("exps", new string[] { }),
				MakePair("exp", new string[] { "INTEGER" })
			);
			Console.WriteLine(sw.ElapsedMilliseconds);
		}
	}
