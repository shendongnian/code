          byte[] a = File.ReadAllBytes(txt_a_path.Text);
          byte[] b = File.ReadAllBytes(txt_b_path.Text);
          byte[] c = new byte[a.Length + b.Length];
          a.CopyTo(c, 0);
          b.CopyTo(c, a.Length);
          File.WriteAllBytes(txt_c_path.Text, c);
