    <asp:Button id="Button1"
               Text="Click "
               OnClick="Btn1_Click" 
               runat="server"/>
    
    <asp:Button id="Button2"
               Text="Click "
               OnClick="Btn2_Click" 
               runat="server"/>
    
    void Btn2_Click(Object sender, EventArgs e)
    {
        Button1.Text = "test after click on button 2";
        Template = ...;//Set your value
    }
    
    
    void Btn1_Click(Object sender, EventArgs e)
    {
        Button2.Text = "test after click on button 1";
        //Here you can get your value after post.
        var result = Template; 
    }
