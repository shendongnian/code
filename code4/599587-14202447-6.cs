protected void Page_Load()
{
    myButton.Click += new EventHandler(this.myButton_Click);
}
[PrincipalPermission(SecurityAction.Demand, Role = "Administrator")]
private void myButton_Click(object sender, EventArgs e)
{
    //your code to handle the event
}
