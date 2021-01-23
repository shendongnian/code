      private void OnChanged(object sender, FileSystemEventArgs e)
      {
           if (!m_bDirty)
           {
                 m_Sb.Remove(0, m_Sb.Length);
                 m_Sb.Append(e.FullPath);
                 m_Sb.Append(" ");
                 m_Sb.Append(e.ChangeType.ToString());
                 m_Sb.Append("    ");
                 m_Sb.Append(DateTime.Now.ToString());
                 m_bDirty = true;
                 list = new List<string>(File.ReadAllLines(txtPath));
                 bindingList = new BindingList<string>(list);
                 listBox1.DataSource = bindingList;
            }
        }
