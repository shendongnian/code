    protected void Page_Load(object sender, EventArgs e)
    {
        var ex = HttpContext.Current.Server.GetLastError();
        if (ex is HttpException)
        {
            var nex = ex as HttpException;
            //Label in the Main code displays the Error Code from the Error String
            this.customErrorMessageCode.Text += "Error Code" + " " + nex.GetHttpCode().ToString();
            //Label in the Main code displays the Error Message from the Error String
            this.customErrorMessageLabel.Text += ex.Message.ToString();
            //DIV ID in the Main code displays the entire error message
            this.customErrorMessage.Visible = true;
            switch (nex.GetHttpCode())
            {
                case 404:
                    this.customErrorMessageCode.Text += " Page Not Found";
                    this.customErrorMessageImage.Visible = true;
                    // do somehting cool
                    break;
                case 403:
                    this.customErrorMessageCode.Text += " Forbidden Access";
                    this.customErrorMessageImage.Visible = true;
                    // do somehting cool
                    break;
                case 500:
                    this.customErrorMessageCode.Text += " Internal Error";
                    this.customErrorMessageImage.Visible = true;
                    // do somehting cool
                    break;
                default:
                    break;
            }
        }
        else {
            this.customErrorMessageLabel.Text += ex.Message + ex.GetType().ToString();
        }
    }
