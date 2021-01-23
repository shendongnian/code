    public class Class1
    {
        // Declare all the controls as dynamic
        dynamic textbox1, textbox2, textbox3, textbox4;
        dynamic label1, label2, label3, label4;
        public Class1()
        {
            // Create the actual object type, which they will hold at Run time. 
            textbox1 = textbox2 = textbox3 = textbox4 = new TextBox();
            label1 = label2 = label3 = label4 = new Label();
            // Loop through to create controls at Runtime.
            n++;
            TextBox txt = new TextBox();
            txt.Name = "textbox" + n;
            txt.Text = "";
            txt.Size = new System.Drawing.Size(189, 26);
            txt.Location = new Point(87, n2);
            testelogico = txt.Name;
            gpbCategoria.Controls.Add(txt);
            txt.TextChanged += new EventHandler(new_onchange);
            txt.Leave += new EventHandler(erase_onLeave);
            Label lbl = new Label();
            lbl.Name = "label" + n;
            lbl.Text = "Acessório Nº" + n + ":";
            lbl.Location = new Point(4, n2 + 5);
            gpbCategoria.Controls.Add(lbl);
            
        }
        public void Foo()
        {
            //Throw exception if controls are not initialized yet.
            if (textbox4 == null || label4 == null)
            {
                throw new Exception("Controls not initialized.");
            }
            else
            {
                // You can access the control propoties similar to normal controls.
                if (textbox4.Text == "" && label4.Name == "Acessório Nº4:")
                {
                    gpbCategoria.Controls.Remove(textbox4);
                    gpbCategoria.Controls.Remove(label4);
                }
            }
        }
    }
