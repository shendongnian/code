<Code>
            // using an Array:
            TextBox[] textBox = new TextBox[5];
            textBox[0] = new TextBox() { Location = new Point(), /* etc */};
            // or
            textBox[0] = TextBox0; // if you already have a TextBox named TextBox0
            // loop it:
            for (int i = 0; i < textBox.Length; i++)
            {
                textBox[i].Text = "";
            }
            // using a List:  (you need to reference System.Collections.Generic)
            List<TextBox> textBox = new List<TextBox>();
            textBox.Add(new TextBox() { Name = "", /* etc */});
            // or
            textBox.Add(TextBox0); // if you already have a TextBox named TextBox0
            
            // loop it:
            for (int i = 0; i < textBox.Count; i++)
            {
                textBox[i].Text = "";
            }
</Code>
