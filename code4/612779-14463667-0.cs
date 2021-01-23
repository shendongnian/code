        NotesViewEntryCollection  notesViewCollection = LotusNotesView.AllEntries;
    	NotesViewEntry viewEntry = notesViewCollection.GetFirstEntry();
    
    	while (viewEntry != null)
        {
            //Get the first document of particular entry.
            NotesDocument document =  viewEntry.Document;
    
            object documentItems = document.Items;
            Array itemArray1 = (System.Array)documentItems;
    
            for( int itemCount=0 ; itemCount< itemArray1.Length; itemCount++ )
            {
                NotesItem notesItem = 
    			(Domino.NotesItem)itemArray1.GetValue( itemCount );
    
                //compare field value with specific value entered by user
                if( notesItem.Text !=null )
                {
                    if( (notesItem.Text.ToUpper()).StartsWith( fieldValue ))
                    {
                        Contact contact = new Contact();
                        for( int icount=0 ; icount< itemArray1.Length; icount++ )
                        {
                            NotesItem searchedNotesItem =
    			(Domino.NotesItem)itemArray1.GetValue( icount );
                            string FieldName = searchedNotesItem.Name.ToString();
                            //For FirstName
                            if( searchedNotesItem.Name == "FirstName" )
                                contact.FirstName= searchedNotesItem.Text;
    
                            //For LastName
                            if( searchedNotesItem.Name == "LastName" )
                                contact.LastName = searchedNotesItem.Text;
                            //For Office Phone Number
                            if( searchedNotesItem.Name == "OfficePhoneNumber" )
                                contact.OfficePhoneNumber = searchedNotesItem.Text;
    
                            if( searchedNotesItem.Name  == "InternetAddress" )
                                contact.EmailId = searchedNotesItem.Text;
    
                        }//end for
                        contactsList.Add( contact );
                        break;
                    }//End if
                }
            }
    		
    		//Get the nth entry of the selected view according to the iteration.
            NotesViewEntry viewEntry = notesViewCollection.GetNextEntry(viewEntry);        
        }
