    public partial class Form1 : Form
    {
        public MethodInfo refreshMethod;
        public Form1()
        {
            InitializeComponent();
            // Build Data
            var list = new List<MyData>
                {
                    new MyData {Id = 1, Str = "1"},
                    new MyData {Id = 2, Str = "2"}
                };
            //Bind Data
            bindingSource1.DataSource = list;
            dataGridView1.DataSource = bindingSource1;
            bindingNavigator1.BindingSource = bindingSource1;
            // get event handler storage property
            var eventsProperty = bindingNavigator1.AddNewItem.GetType().GetProperty(
                "Events",
                BindingFlags.FlattenHierarchy | BindingFlags.NonPublic | BindingFlags.Instance
                );
            // get key for click event
            var clickField = bindingNavigator1.AddNewItem.GetType().GetField(
                "EventClick",
                BindingFlags.FlattenHierarchy | BindingFlags.NonPublic | BindingFlags.Static
                );
            var clickKey = clickField.GetValue(null);
            // find refresh method
            refreshMethod = bindingNavigator1.GetType().GetMethod(
                "RefreshItemsInternal",
                BindingFlags.FlattenHierarchy | BindingFlags.NonPublic | BindingFlags.Instance
                );
            // get storage instance
            var handlers = (EventHandlerList)eventsProperty.GetValue(bindingNavigator1.AddNewItem, null);
            // find click event handlers
            var clickEventHandlers = handlers[clickKey];
            // remove current handlers
            var handlerInvocationList = clickEventHandlers.GetInvocationList();
            for (int index = 0; index < handlerInvocationList.Length; index++)
                handlers.RemoveHandler(clickKey, handlerInvocationList[index]);
            
            // attach our new handler
            handlers.AddHandler(clickKey, new EventHandler(NewAddNewHandler));
        }
        private void NewAddNewHandler(object sender, EventArgs e)
        {
            if (bindingNavigator1.Validate() && null != bindingNavigator1.BindingSource)
            {
                var result = MessageBox.Show("Add new?", "Are you..", MessageBoxButtons.YesNo) == DialogResult.Yes;
                if (!result)
                    return;
                bindingNavigator1.BindingSource.AddNew();
                refreshMethod.Invoke(bindingNavigator1, null);
            }
        }
    }
