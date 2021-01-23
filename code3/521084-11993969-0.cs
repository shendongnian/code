    Label label1 = new Label();
        label1.Text = "Test 1";
        form1.Controls.Add(label1);
        form1.Controls.Add(new Literal() { ID="row", Text="<hr/>" } );
        
        Label label2 = new Label();
        label2.Text = "Test 2";
        form1.Controls.Add(label2);
    Output:
    Test 1
    ---------------------------------------------------------------------------------
    Test 2
