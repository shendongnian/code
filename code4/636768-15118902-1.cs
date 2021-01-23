        {
            return Lists.verbList[Lists.randomverb.Next(0, Lists.verbList.Count)];
        }
        public void button1_Click(object sender, EventArgs e)
        {
            if (Lists.verbList.Count > 0) verb.Text = pickRandomVerb();
        }
