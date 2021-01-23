    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Forms;
    using System.Drawing;
    
    namespace System.Windows.Forms
    {
      public static class TSFormExtenders
      {
        #region Control
        public static void SetEnabledTS(this Control x, bool s)
        {
          if (x.InvokeRequired)
          {
            x.Invoke(new EventHandler(delegate(object o, EventArgs a)
            {
              x.SetEnabledTS(s);
            }));
          }
          else
          {
            x.Enabled = s;
          }
        }
    
        public static bool GetEnabledTS(this Control x, bool def = false)
        {
          if (x.InvokeRequired)
          {
            bool m_ret = def;
            x.Invoke(new EventHandler(delegate(object o, EventArgs a)
            {
              m_ret = x.GetEnabledTS();
            }));
            return m_ret;
          }
          else
          {
            return x.Enabled;
          }
        }
    
        public static void SetTextTS(this Control x, String s)
        {
          if (x.InvokeRequired)
          {
            x.Invoke(new EventHandler(delegate(object o, EventArgs a)
            {
              x.SetTextTS(s);
            }));
          }
          else
          {
            x.Text = s;
          }
        }
    
        public static String GetTextTS(this Control x, String def = "")
        {
          if (x.InvokeRequired)
          {
            String m_ret = def;
            x.Invoke(new EventHandler(delegate(object o, EventArgs a)
            {
              m_ret = x.GetTextTS();
            }));
            return m_ret;
          }
          else
          {
            return x.Text;
          }
        }
    
        public static void SetVisibleTS(this Control x, bool s)
        {
          if (x.InvokeRequired)
          {
            x.Invoke(new EventHandler(delegate(object o, EventArgs a)
            {
              x.SetVisibleTS(s);
            }));
          }
          else
          {
            x.Visible = s;
          }
        }
    
        public static bool GetVisibleTS(this Control x, bool def = true)
        {
          if (x.InvokeRequired)
          {
            bool m_ret = def;
            x.Invoke(new EventHandler(delegate(object o, EventArgs a)
            {
              m_ret = x.GetVisibleTS();
            }));
            return m_ret;
          }
          else
          {
            return x.Visible;
          }
        }
    
        public static void SetSizeTS(this Control x, Size s)
        {
          if (x.InvokeRequired)
          {
            x.Invoke(new EventHandler(delegate(object o, EventArgs a)
            {
              x.SetSizeTS(s);
            }));
          }
          else
          {
            x.Size = s;
          }
        }
    
        public static Size GetSizeTS(this Control x)
        {
          if (x.InvokeRequired)
          {
            Size m_ret = new Size();
            x.Invoke(new EventHandler(delegate(object o, EventArgs a)
            {
              m_ret = x.GetSizeTS();
            }));
            return m_ret;
          }
          else
          {
            return x.Size;
          }
        }
        #endregion
    
        #region CheckBox
        public static void SetCheckedTS(this CheckBox x, bool s)
        {
          if (x.InvokeRequired)
          {
            x.Invoke(new EventHandler(delegate(object o, EventArgs a)
            {
              x.SetCheckedTS(s);
            }));
          }
          else
          {
            x.Checked = s;
          }
        }
    
        public static bool GetCheckedTS(this CheckBox x)
        {
          if (x.InvokeRequired)
          {
            bool m_ret = false;
            x.Invoke(new EventHandler(delegate(object o, EventArgs a)
            {
              m_ret = x.GetCheckedTS();
            }));
            return m_ret;
          }
          else
          {
            return x.Checked;
          }
        }
        #endregion
    
        #region NumericUpDown
        public static void SetValueTS(this NumericUpDown x, Decimal s)
        {
          if (x.InvokeRequired)
          {
            x.Invoke(new EventHandler(delegate(object o, EventArgs a)
            {
              x.SetValueTS(s);
            }));
          }
          else
          {
            x.Value = s;
          }
        }
    
        public static Decimal GetValueTS(this NumericUpDown x)
        {
          if (x.InvokeRequired)
          {
            Decimal m_ret = 0;
            x.Invoke(new EventHandler(delegate(object o, EventArgs a)
            {
              m_ret = x.GetValueTS();
            }));
            return m_ret;
          }
          else
          {
            return x.Value;
          }
        }
    
        public static void SetMinTS(this NumericUpDown x, Decimal s)
        {
          if (x.InvokeRequired)
          {
            x.Invoke(new EventHandler(delegate(object o, EventArgs a)
            {
              x.SetMinTS(s);
            }));
          }
          else
          {
            x.Minimum = s;
          }
        }
    
        public static void SetMaxTS(this NumericUpDown x, Decimal s)
        {
          if (x.InvokeRequired)
          {
            x.Invoke(new EventHandler(delegate(object o, EventArgs a)
            {
              x.SetMaxTS(s);
            }));
          }
          else
          {
            x.Maximum = s;
          }
        }
        #endregion
    
        #region ProgressBar
        public static void SetValueTS(this ProgressBar x, Int32 s)
        {
          if (x.InvokeRequired)
          {
            x.Invoke(new EventHandler(delegate(object o, EventArgs a)
            {
              x.SetValueTS(s);
            }));
          }
          else
          {
            x.Value = s;
          }
        }
    
        public static Int32 GetValueTS(this ProgressBar x)
        {
          if (x.InvokeRequired)
          {
            Int32 m_ret = 0;
            x.Invoke(new EventHandler(delegate(object o, EventArgs a)
            {
              m_ret = x.GetValueTS();
            }));
            return m_ret;
          }
          else
          {
            return x.Value;
          }
        }
    
        public static void SetMinTS(this ProgressBar x, Int32 s)
        {
          if (x.InvokeRequired)
          {
            x.Invoke(new EventHandler(delegate(object o, EventArgs a)
            {
              x.SetMinTS(s);
            }));
          }
          else
          {
            x.Minimum = s;
          }
        }
    
        public static void SetMaxTS(this ProgressBar x, Int32 s)
        {
          if (x.InvokeRequired)
          {
            x.Invoke(new EventHandler(delegate(object o, EventArgs a)
            {
              x.SetMaxTS(s);
            }));
          }
          else
          {
            x.Maximum = s;
          }
        }
        #endregion
    
        #region ListView
        public static void AddItemTS(this ListView x, ListViewItem s)
        {
          if (x.InvokeRequired)
          {
            x.Invoke(new EventHandler(delegate(object o, EventArgs a)
            {
              x.AddItemTS(s);
            }));
          }
          else
          {
            x.Items.Add(s);
          }
        }
    
        public static void AddItemTS(this ListViewItem x, System.Windows.Forms.ListViewItem.ListViewSubItem s)
        {
          if (x.ListView.InvokeRequired)
          {
            x.ListView.Invoke(new EventHandler(delegate(object o, EventArgs a)
            {
              x.AddItemTS(s);
            }));
          }
          else
          {
            x.SubItems.Add(s);
          }
        }
        #endregion
      }
    }
