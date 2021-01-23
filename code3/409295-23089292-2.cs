    using System;
    using System.Linq;
    using System.Data;
    using System.Collections;
    using System.Runtime.InteropServices;
    using Microsoft.Win32;
    using Domino;
    using System.Text;
    using System.IO;
    using System.Collections.Generic;
    
    namespace NotesScraper
    {
    	public class NotesCommunication
    	{
    		public  KeyValuePair<string, NotesViewResultSet[]>[] PullNotesView(string[] ViewNames, string server, string database, string password )
    		{
    			if (ViewNames == null || ViewNames.Length == 0 || ViewNames.ToList().Distinct().Count() != ViewNames.Length )
    			{
    				throw new ArgumentException();
    			}
    			else
    			{
    				List<KeyValuePair<string, NotesViewResultSet[]>> results = new List<KeyValuePair<string, NotesViewResultSet[]>>();
    				NotesSession notesSession = new Domino.NotesSession();
    				notesSession.Initialize(password);
    				NotesDatabase notesDatabase = notesSession.GetDatabase(server, database, false);
    				for(int i=0; i<ViewNames.Length; i++)
    				{
    					List<NotesViewResultSet> result = new List<NotesViewResultSet>();
    					Domino.NotesView notesView;
    					string view = ViewNames[i];
    					notesView = notesDatabase.GetView(view);
    					NotesViewEntryCollection notesViewCollection = notesView.AllEntries;
    					for (int rowCount = 1; rowCount <= notesViewCollection.Count; rowCount++)
    					{
    						NotesViewEntry viewEntry = notesViewCollection.GetNthEntry(rowCount);
    						NotesDocument document = viewEntry.Document;
    						Array notesThings = document.Items as Array;
    						for (int j = 0; j < notesThings.Length; j++)
    						{
    							NotesItem notesItem = (notesThings.GetValue(j) as Domino.NotesItem);
    							result.Add(new NotesViewResultSet() 
    							{ 
    								RecordID = rowCount,
    								Name = notesItem.Name,
    								Value = notesItem.Text
    							});
    						}
    					}
    					results.Add(new KeyValuePair<string,NotesViewResultSet[]>(view, result.ToArray()));
    				}
    				return results.ToArray();
    			}
    		}
    	}
    	public class NotesViewResultSet
    	{
    		public int RecordID {get;set;}
    		public string Name { get; set; }
    		public string Value { get; set; }
    	}
    }
