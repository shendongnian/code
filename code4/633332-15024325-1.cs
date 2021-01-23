        void From_Click(object sender, EventArgs e)
        {
            mainTChart.Axes.Bottom.AutomaticMaximum = false;
            mainTChart.Axes.Bottom.Maximum = m_dblTempVolFromTo;
        }
        void To_Click(object sender, EventArgs e)
        {
            mainTChart.Axes.Bottom.AutomaticMinimum = false;
            mainTChart.Axes.Bottom.Minimum = m_dblTempVolFromTo;
        } 
