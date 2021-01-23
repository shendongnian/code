    public List<string> MyList { get; set; }
    
    private void button1_Click( object sender, EventArgs e )
    {
        MyList = new List<string>();
    
        var bw = new BackgroundWorker();
        bw.DoWork += ( o, args ) => MethodToDoWork();
        bw.RunWorkerCompleted += ( o, args ) => MethodToUpdateControl();
        bw.RunWorkerAsync();
    }
    
    private void MethodToDoWork()
    {
        for( int i = 0; i < 10; i++ )
        {
            MyList.Add( string.Format( "item {0}", i ) );
            System.Threading.Thread.Sleep( 100 );
        }
    }
    
    private void MethodToUpdateControl()
    {
        // since the BackgroundWorker is designed to use
        // the form's UI thread on the RunWorkerCompleted
        // event, you should just be able to add the items
        // to the list box:
        listBox1.Items.AddRange( MyList.ToArray() );
        // the above should not block the UI, if it does
        // due to some other code, then use the ListBox's
        // Invoke method:
        // listBox1.Invoke( new Action( () => listBox1.Items.AddRange( MyList.ToArray() ) ) );
    }
