     public class SafeListBox : ListBox 
        { 
            delegate void insertDelegate(int i, object o); 
     
            public SafeListBox() 
            { 
                this.Items = new CustomObjectCollection(this); 
            } 
     
            public new CustomObjectCollection Items 
            { 
                get; 
                set; 
            } 
     
            public class CustomObjectCollection : ListBox.ObjectCollection 
            { 
                private ListBox listBox = null; 
     
                public CustomObjectCollection(ListBox listBox) : base(listBox) 
                { 
                    this.listBox = listBox; 
                } 
     
                public new void Insert(int index, object item) 
                { 
                    if (listBox.InvokeRequired) 
                    { 
                        insertDelegate setTextDel = delegate(int i, object o) 
                        { 
                            base.Insert(i, o); 
                        }; 
     
                        try 
                        { 
                            listBox.Invoke(setTextDel, new object[] { index, item }); 
                        } 
                        catch 
                        { 
                        } 
                    } 
                    else 
                    { 
                        base.Insert(index,item); 
                    } 
                } 
            } 
        }
   
