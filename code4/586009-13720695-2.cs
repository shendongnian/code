    public partial class Form1 : Form
    {
        Messages _messages = Messages.Instance; // Singleton reference to the Messages class. This contains the shared event
                                                // and messages list.
    
        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
    public Form1()
    {
        InitializeComponent();
        // Subscribe to the message event. This will allow the form to be notified whenever there's a new message.
        //
        _messages.HandleMessage += new EventHandler(OnHandleMessage);
        // If there any existing messages that other forms have sent, populate list with them.
        //
        foreach (var messages in _messages.CurrentMessages)
        {
            listView1.Items.Add(messages);
        }
    }
    /// <summary>
    /// Handles the Click event of the buttonNewForm control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void buttonNewForm_Click(object sender, EventArgs e)
    {
        // Create a new form to display..
        //
        var newForm = new Form1();
        newForm.Show();
    }
    /// <summary>
    /// Handles the Click event of the buttonSend control. Adds a new message to the "central" message list.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void buttonSend_Click(object sender, EventArgs e)
    {
        string message = String.Format("{0} -- {1}", DateTime.UtcNow.ToLongTimeString(), textBox1.Text);
        textBox1.Clear();
        _messages.AddMessage(message);
    }
    /// <summary>
    /// Called when [handle message].
    /// This is called whenever a new message has been added to the "central" list.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="args">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    public void OnHandleMessage(object sender, EventArgs args)
    {
        var messageEvent = args as MessageEventArgs;
        if (messageEvent != null)
        {
            string message = messageEvent.Message;
            listView1.Items.Add(message);
        }
    }
