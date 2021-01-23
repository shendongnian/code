    using System;
    using System.Text.RegularExpressions;
    namespace WebApplication1
    {
        public partial class _Default : System.Web.UI.Page
        {
            protected void Button1_Click(object sender, EventArgs e)
            {
                string code = "protected void Page_Load(object sender, EventArgs e)\n{\n\tResponse.Write(\"Hello World\");\n}";
                Regex regex = new Regex(@"^\t+", RegexOptions.Multiline);
                TextBox1.Text = regex.Replace(code, m => new string('*', 4 * m.Value.Length));
            }
        }
    }
