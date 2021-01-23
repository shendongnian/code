    private void EditButton_Click(object sender, EventArgs e)
    {
      IntPtr hdc = richTextBox1.CreateGraphics().GetHdc();
      string str = "aaa bbb ccc ddd eee fff";
      
      SetTextJustification(hdc, 40, 5);
      TextOut(hdc, 20, 20, str, str.Length);
      
      SetTextJustification(hdc, 10, 5);
      TextOut(hdc, 20, 40, str, str.Length);
      
      // Another Approach:
      Graphics g = richTextBox1.CreateGraphics();
      PaintTextJustification(g, str, richTextBox1.Font, new PointF(20f, 90f), 220, true);
      System.Drawing.Font newFont = new Font("Arial", 12f, FontStyle.Bold);
      string longStr = "This is a very long string which will need to be split across several lines when it is justified.";
      PaintTextJustification(g, longStr, newFont, new PointF(20f, 110f), 220, false);
    }
