    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                this.dataGridView1.Dock = DockStyle.Fill;
            }
            protected override void OnLoad(EventArgs e)
            {
                base.OnLoad(e);
                dataGridView1.DataSource = new List<MyClass>
                        {
                          new MyClass("value 1", "value 2", "value 3"),
                          new MyClass("value 1", "value 2"),
                        };
            }
            class MyClass : CustomTypeDescriptor
            {
                public MyClass(params string[] tags)
                {
                    this.tags = new List<string>(tags);
                }
                public override PropertyDescriptorCollection GetProperties(Attribute[] attributes)
                {
                    var listProps = new List<PropertyDescriptor>();
                    // adding properties dynamically
                    for (int i = 0; i < tags.Count; i++)
                        listProps.Add(new PropDesc("Tag" + i, i));
                    return new PropertyDescriptorCollection(listProps.ToArray());
                }
                private List<string> tags = new List<string>();
                class PropDesc : PropertyDescriptor
                {
                    private int index;
                    public PropDesc(string propName, int index)
                        : base(propName, new Attribute[0])
                    {
                        this.index = index;
                    }
                    public override bool CanResetValue(object component) { return false; }
                    public override Type ComponentType { get { return typeof(MyClass); } }
                    public override object GetValue(object component)
                    {
                        if (index >= ((MyClass)component).tags.Count)
                            return null;
                        return ((MyClass)component).tags[index];
                    }
                    public override bool IsReadOnly { get { return true; } }
                    public override Type PropertyType { get { return typeof(string); } }
                    public override void ResetValue(object component) { }
                    public override void SetValue(object component, object value) { }
                    public override bool ShouldSerializeValue(object component) { return false; }
                }
            }
            private void InitializeComponent()
            {
                this.dataGridView1 = new DataGridView();
                ((ISupportInitialize)(this.dataGridView1)).BeginInit();
                this.SuspendLayout();
                // dataGridView1
                this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                this.dataGridView1.Dock = DockStyle.Fill;
                this.dataGridView1.Location = new System.Drawing.Point(0, 0);
                this.dataGridView1.Name = "dataGridView1";
                this.dataGridView1.Size = new System.Drawing.Size(284, 262);
                this.dataGridView1.TabIndex = 1;
                // Form1
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(284, 262);
                this.Controls.Add(this.dataGridView1);
                this.Name = "Form1";
                this.Text = "Form1";
                ((ISupportInitialize)(this.dataGridView1)).EndInit();
                this.ResumeLayout(false);
            }
            private DataGridView dataGridView1;
        }
    }
