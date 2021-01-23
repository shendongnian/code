        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Match match = Regex.Match(txtString.Text, @"""\s*(.*?)\s*""",
                RegexOptions.IgnoreCase);
            if (match.Success)
            {
                string key = match.Groups[1].Value;
                lblFinal.Text = key;
            }
        }
