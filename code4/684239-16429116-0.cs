    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    
    namespace DataExample
    {
        public class Form1 : Form
        {
            private string _Filename = "MyAnimals.xml";
            public List<Animal> myAnimals = new List<Animal>();
            public Form1()
            {
                InitializeComponent();
            }
    
            public void RegisterDog(String name)
            {
                myAnimals.Add(new Dog { Name = name });
            }
            public void RegisterCat(String name)
            {
                myAnimals.Add(new Cat { Name = name });
            }
    
            private DataGridView dataGridView1;
            private Button button1;
            private Button button2;
    
            /// <summary>
            /// Required designer variable.
            /// </summary>
            private System.ComponentModel.IContainer components = null;
    
            /// <summary>
            /// Clean up any resources being used.
            /// </summary>
            /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
            protected override void Dispose(bool disposing)
            {
                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }
    
            #region Windows Form Designer generated code
    
            /// <summary>
            /// Required method for Designer support - do not modify
            /// the contents of this method with the code editor.
            /// </summary>
            private void InitializeComponent()
            {
                this.dataGridView1 = new System.Windows.Forms.DataGridView();
                this.button1 = new System.Windows.Forms.Button();
                this.button2 = new System.Windows.Forms.Button();
                ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
                this.SuspendLayout();
                // 
                // dataGridView1
                // 
                this.dataGridView1.AllowUserToAddRows = false;
                this.dataGridView1.AllowUserToDeleteRows = false;
                this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                this.dataGridView1.Location = new System.Drawing.Point(12, 12);
                this.dataGridView1.Name = "dataGridView1";
                this.dataGridView1.Size = new System.Drawing.Size(260, 199);
                this.dataGridView1.TabIndex = 0;
                // 
                // button1
                // 
                this.button1.Location = new System.Drawing.Point(12, 229);
                this.button1.Name = "button1";
                this.button1.Size = new System.Drawing.Size(85, 21);
                this.button1.TabIndex = 1;
                this.button1.Text = "persist to file";
                this.button1.UseVisualStyleBackColor = true;
                this.button1.Click += new System.EventHandler(this.button1_Click);
                // 
                // button2
                // 
                this.button2.Location = new System.Drawing.Point(151, 229);
                this.button2.Name = "button2";
                this.button2.Size = new System.Drawing.Size(121, 21);
                this.button2.TabIndex = 2;
                this.button2.Text = "make dummy objects";
                this.button2.UseVisualStyleBackColor = true;
                this.button2.Click += new System.EventHandler(this.button2_Click);
                // 
                // Form1
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(284, 262);
                this.Controls.Add(this.button2);
                this.Controls.Add(this.button1);
                this.Controls.Add(this.dataGridView1);
                this.Name = "Form1";
                this.Text = "Form1";
                this.Load += new System.EventHandler(this.Form1_Load);
                ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
                this.ResumeLayout(false);
    
            }
    
            #endregion
    
            private void button2_Click(object sender, EventArgs e)
            {
                RegisterDog("SomeDog");
                RegisterCat("SomeCat");
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = myAnimals;
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                try
                {
                    using (System.Xml.XmlWriter xmlWriter = System.Xml.XmlWriter.Create(_Filename))
                    {
                        System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(List<Animal>), new Type[] { typeof(Dog), typeof(Cat) });
                        serializer.Serialize(xmlWriter, myAnimals);
                    }
                }
                catch { }
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                try
                {
                    using (System.Xml.XmlReader xmlReader = System.Xml.XmlReader.Create(_Filename))
                    {
                        System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(List<Animal>), new Type[] { typeof(Dog), typeof(Cat) });
                        myAnimals = (List<Animal>)serializer.Deserialize(xmlReader);
                        dataGridView1.DataSource = myAnimals;
                    }
                }
                catch { }
            }
        }
        [Serializable]
        public abstract class Animal
        {
            public String Name { get; set; }
            public abstract String Species { get; }
        }
        [Serializable]
        public class Dog : Animal
        {
    
            public override string Species
            {
                get { return "Dog"; }
            }
        }
        [Serializable]
        public class Cat : Animal
        {
    
            public override string Species
            {
                get { return "Cat"; }
            }
        }
    
    }
