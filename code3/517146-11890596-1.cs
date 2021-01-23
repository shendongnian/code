    private static Random r = new Random();
    private string GenerateRandomNumber()
    {
        return r.Next(111111111, 999999999).ToString();
    }
    protected void btnSolo_Click(object sender, EventArgs e)
    {
        Response.Write(GenerateRandomNumber());
    }
    protected void btnBulk_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < 100; i++)
        {
            string randomNumber = GenerateRandomNumber();
            Response.Write("<br /> " + randomNumber);
        }
    }
