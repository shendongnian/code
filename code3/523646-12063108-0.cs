        // class for storing values
        public class SlotItem
        {
            public object Val { get; private set; }
            public Type ValType { get; private set; }
            public SlotItem(object o, Type valType)
            {
                Val = o;
                ValType = valType;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            // store values to List
            List<SlotItem> list = new List<SlotItem>();
            list.Add(new SlotItem("sometext", typeof(String))); // store text
            list.Add(new SlotItem(100, typeof(Int32)));         // store number
            // read values from List
            foreach (SlotItem slot in list)
            {
                var val = Convert.ChangeType(slot.Val, slot.ValType);
                Response.Write(val);
            }
        }
