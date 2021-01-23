    #region Initial Values
    //Constructor:
    public Form1() {
       InitializeComponent();
    }
    
    private void Form1_Load( object sender, EventArgs e ) {
       InitialValues();
    }
    
    private void InitialValues() {
       PrepareDragAndDrop();
    }
    #endregion Initial Values
    
    #region Drag & Drop
    
    private void PrepareDragAndDrop() {
       //For the object that receives the other dragged element:
       TheSamplListBox.AllowDrop = true;
       TheSamplListBox.DragEnter += TheSamplListBox_DragEnter;
       TheSamplListBox.DragLeave += TheSamplListBox_DragLeave;
       TheSamplListBox.DragDrop  += TheSamplListBox_DragDrop;
    
       //For the object that will be dragged:
       TheSampleLabel.MouseDown += ( sender, args ) => DoDragDrop( TheSampleLabel.Text, DragDropEffects.Copy );
    }
    
    private void TheSamplListBox_DragEnter( object theReceiver, DragEventArgs theEventData ) {
       theEventData.Effect = DragDropEffects.Copy;
    
       //Only the code above is strictly for the Drag & Drop. The following is for user feedback:
       //You can use [TheSamplListBox] but this approach allows for multiple receivers of the same type:
       var theReceiverListBox = (ListBox) theReceiver;
    
       theReceiverListBox.BackColor = Color.LightSteelBlue;
    }
    
    private void TheSamplListBox_DragLeave( object theReceiver, EventArgs theEventData ) {
       //No code here for the Drag & Drop. The following is for user feedback:
       //You can use [TheSamplListBox] but this approach allows for multiple receivers of the same type:
       var theReceiverListBox = (ListBox) theReceiver;
    
       theReceiverListBox.BackColor = Color.White;
    }
    
    private void TheSamplListBox_DragDrop( object theReceiver, DragEventArgs theEventData ) {
       //You can use [TheSamplListBox] but this approach allows for multiple receivers of the same type:
       var theReceiverListBox = (ListBox) theReceiver;
    
       //Get the data being dropped. In this case, a string:
       var theStringBeingDropped = theEventData.Data.GetData( "System.String" );
    
       //Add the string to the ListBox:
       theReceiverListBox.Items.Add( theStringBeingDropped );
    
       //Only the code above is strictly for the Drag & Drop. The following is for user feedback:
       theReceiverListBox.BackColor = Color.White;
    }
    #endregion Drag & Drop
.
