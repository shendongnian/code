    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using System.Windows.Forms.Design;
    
    namespace PropertyGrid_ListBox_Test
    {
        public partial class TypeCodeSelectionControl : UserControl
        {
            public List<TypeCodes> List { get; set; }
            private IWindowsFormsEditorService editorService;
    
            public TypeCodeSelectionControl()
            {
                InitializeComponent();
            }
    
            private void PrepareListBoxes()
            {
                foreach (string myType in Enum.GetNames(typeof(TypeCodes)))
                    listBox1.Items.Add(myType);
    
                foreach (TypeCodes type_code in this.List)
                {
                    string enum_value = Enum.GetName(typeof(TypeCodes), type_code);
                    listBox1.Items.Remove(enum_value);
                    listBox2.Items.Add(enum_value);
                }
            }
    
            public TypeCodeSelectionControl(List<TypeCodes> list, IWindowsFormsEditorService editorService)
            {
                InitializeComponent();
    
                this.List = list;
                this.editorService = editorService;
    
                PrepareListBoxes();
            }
    
            private void buttonALL_Click(object sender, EventArgs e)
            {
                //
                // Add all items.
                //
                foreach (object obj in listBox1.Items)
                {
                    listBox2.Items.Add(obj);
                }
                listBox1.Items.Clear();
            }
    
            private void buttonAdd_Click(object sender, EventArgs e)
            {
                //
                // Add selected item.
                //
                string item_to_add = (string)listBox1.SelectedItem;
                listBox1.Items.Remove(item_to_add);
                listBox2.Items.Add(item_to_add);
            }
    
            private void buttonRemove_Click(object sender, EventArgs e)
            {
                //
                // Remove selected item.
                //
                string item_to_remove = (string)listBox2.SelectedItem;
                listBox2.Items.Remove(item_to_remove);
                listBox1.Items.Add(item_to_remove);
            }
    
            private void buttonNone_Click(object sender, EventArgs e)
            {
                //
                // Remove all items.
                //
                foreach (object obj in listBox2.Items)
                {
                    listBox1.Items.Add(obj);
                }
                listBox2.Items.Clear();
            }
    
            private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
            {
                //
                // Enable "Add" button only if any of items is selected in the left listbox.
                //
                buttonAdd.Enabled = listBox1.SelectedIndex != -1;
            }
    
            private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
            {
                //
                // Enable "Remove" button only if any of items is selected in the right listbox.
                //
                buttonRemove.Enabled = listBox2.SelectedIndex != -1;
            }
    
            protected override void OnVisibleChanged(EventArgs e)
            {
                base.OnVisibleChanged(e);
    
                //
                // This occures when dropdown UI editor is hiding.
                //
                if (this.Visible == false)
                {
                    //
                    // Clear previously selected items.
                    //
                    if (this.List == null)
                    {
                        this.List = new List<TypeCodes>();
                    }
                    else
                    {
                        this.List.Clear();
                    }
    
                    //
                    // Fill the list with currently selected items.
                    //
                    foreach (string obj in listBox2.Items)
                    {
                        this.List.Add((TypeCodes)Enum.Parse(typeof(TypeCodes), obj));
                    }
                    editorService.CloseDropDown();
                }
            }
        }
    }
