    StringBuilder sb = new StringBuilder();
    for(int sides = 3; sides < 10000; sides++) {
        double pi_est = sides * Math.Sin((2*Math.PI)/sides) / 2;
        sb.append(pi_est + "\n");
    }
    richTextBox1.AppendText(sb.ToString());
