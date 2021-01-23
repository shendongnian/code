    private void ListViewLogging_MessageEvent(Category category, MessageEventArgs args)
    {
        // Ensure the event was received in the UI thread
        if(this.InvokeRequired)
        {
            if(args.Message != null)
            {
                // We aren't in the UI thread so reFire the event using the main thread
                this.BeginInvoke(new MessageReceivedDelegate(this.ListViewLogging_MessageEvent), new object[]{category,args});
            }
        }
        else
        {
            // We are currently in the main thread.
            // Lock so no other thread can be handled until event processing has been finished
            lock(this)
            {
                // Create a new ListView item for the new message 
                ListViewItem newEntry = null;;
    
                // Determine the category type
                switch( category.Name )
                {
                    case "Serious":
                    {
                        // Serious error detected
                        if( args.Message.Length > 0 )
                        {
                            newEntry = new ListViewItem( new string[]{category.Name, args.Occurred.ToLongTimeString(), args.Message} );
                            newEntry.BackColor = Color.Red;
                        }
                        break;
                    }
                    case "Warning":
                    {
                        // Warning detected.
                        if( args.Message.Length > 0 )
                        {
                            newEntry = new ListViewItem( new string[]{category.Name, args.Occurred.ToLongTimeString(), args.Message} );
                            newEntry.BackColor = Color.Orange;
                        }
                        break;
                    }
                    case "Progress":
                    {
                        // If a message has been specified, log it
                        if( args.Message.Length > 0 )
                        {
                            newEntry = new ListViewItem( new string[]{"", args.Occurred.ToLongTimeString(), args.Message} );
                        }
                        break;
                    }
                    case "Debug":
                    {
                        // Just a standard Debug event so just display the text on the screen
                        if( args.Message.Length > 0 )
                        {
                            newEntry = new ListViewItem( new string[]{category.Name, args.Occurred.ToLongTimeString(), args.Message} );
                            newEntry.BackColor = Color.LightGreen;
                        }
                        break;
                    }
                    case "Info":
                    default:
                    {
                        // Just a standard event so just display the text on the screen
                        if( args.Message.Length > 0 )
                        {
                            newEntry = new ListViewItem( new string[]{category.Name, args.Occurred.ToLongTimeString(), args.Message} );
                        }
                        break;
                    }
                }
                // Add the item if it's been populated
                if( newEntry != null )
                {
                    this.Items.Add( newEntry );
                    this.EnsureVisible( this.Items.Count-1 );
                }
            }
        }
    }
