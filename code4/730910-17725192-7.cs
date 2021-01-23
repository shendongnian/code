    int counter = 0;
    // Display each item of ArrayList
    foreach (Object row in myArrayList)
    {
        Control ctrl = new Control();
        Label lbl = new Label();
        lbl.Text = "Label " + counter.ToString();
        Button btn = new Button();
        btn.Text = "Button text " + counter.ToString(); 
        btn.Click += delegate(object sender, EventArgs e)
        {
            Response.Write("<script>alert('Message for button " + counter.ToString() + "');</script>");
        }; 
             
        counter++; 
        PlanContent.Controls.Add(ctrl);
    }
