        /// <summary>
    /// SafeGUI supplies functions for safely accessing some typical GUI controls across threads
    /// (This could be expanded to include other popular control properties as well)
    /// </summary>
    public class SafeGuiWpf
    {
        public static string GetText(TextBox TB)
        {
            if (TB.Dispatcher.CheckAccess()) return TB.Text;
            else return (string)TB.Dispatcher.Invoke(new Func<TextBox,string>(GetText), TB);
        }
        public static string GetText(ComboBox TB)
        {
            if (TB.Dispatcher.CheckAccess()) return TB.Text;
            else return (string)TB.Dispatcher.Invoke(new Func<ComboBox,string>(GetText), TB);
        }
        public static string GetText(PasswordBox TB)
        {
            if (TB.Dispatcher.CheckAccess()) return TB.Password;
            else return (string)TB.Dispatcher.Invoke(new Func<PasswordBox, string>(GetText), TB);
        }
        public static void SetText(TextBlock TB, string Str)
        {
            if (TB.Dispatcher.CheckAccess()) TB.Text = Str;
            else TB.Dispatcher.Invoke(new Action<TextBlock,string>(SetText), TB, Str);
        }
        public static void SetText(TextBox TB, string Str)
        {
            if (TB.Dispatcher.CheckAccess()) TB.Text = Str;
            else TB.Dispatcher.Invoke(new Action<TextBox, string>(SetText), TB, Str);
        }
        public static void AppendText(TextBox TB, string Str)
        {
            if (TB.Dispatcher.CheckAccess())
            {
                TB.AppendText(Str);
                TB.ScrollToEnd(); // scroll to end?
            }
            else TB.Dispatcher.Invoke(new Action<TextBox, string>(AppendText), TB, Str);
        }
        public static bool? GetChecked(CheckBox Ck)
        {
            if (Ck.Dispatcher.CheckAccess()) return Ck.IsChecked;
            else return (bool?)Ck.Dispatcher.Invoke(new Func<CheckBox,bool?>(GetChecked), Ck);
        }
        public static void SetChecked(CheckBox Ck, bool? V)
        {
            if (Ck.Dispatcher.CheckAccess()) Ck.IsChecked = V;
            else Ck.Dispatcher.Invoke(new Action<CheckBox, bool?>(SetChecked), Ck, V);
        }
        public static bool GetChecked(MenuItem Ck)
        {
            if (Ck.Dispatcher.CheckAccess()) return Ck.IsChecked;
            else return (bool)Ck.Dispatcher.Invoke(new Func<MenuItem, bool>(GetChecked), Ck);
        }
        public static void SetChecked(MenuItem Ck, bool V)
        {
            if (Ck.Dispatcher.CheckAccess()) Ck.IsChecked = V;
            else Ck.Dispatcher.Invoke(new Action<MenuItem, bool>(SetChecked), Ck, V);
        }
        public static bool? GetChecked(RadioButton Ck)
        {
            if (Ck.Dispatcher.CheckAccess()) return Ck.IsChecked;
            else return (bool?)Ck.Dispatcher.Invoke(new Func<RadioButton, bool?>(GetChecked), Ck);
        }
        public static void SetChecked(RadioButton Ck, bool? V)
        {
            if (Ck.Dispatcher.CheckAccess()) Ck.IsChecked = V;
            else Ck.Dispatcher.Invoke(new Action<RadioButton, bool?>(SetChecked), Ck, V);
        }
        public static void SetVisible(UIElement Emt, Visibility V)
        {
            if (Emt.Dispatcher.CheckAccess()) Emt.Visibility = V;
            else Emt.Dispatcher.Invoke(new Action<UIElement, Visibility>(SetVisible), Emt, V);
        }
        public static bool GetEnabled(UIElement Emt)
        {
            if (Emt.Dispatcher.CheckAccess()) return Emt.IsEnabled;
            else return (bool)Emt.Dispatcher.Invoke(new Func<UIElement, bool>(GetEnabled), Emt);
        }
        public static void SetEnabled(UIElement Emt, bool V)
        {
            if (Emt.Dispatcher.CheckAccess()) Emt.IsEnabled = V;
            else Emt.Dispatcher.Invoke(new Action<UIElement, bool>(SetEnabled), Emt, V);
        }
        public static void SetSelectedItem(Selector Ic, object Selected)
        {
            if (Ic.Dispatcher.CheckAccess()) Ic.SelectedItem = Selected;
            else Ic.Dispatcher.Invoke(new Action<Selector, object>(SetSelectedItem), Ic, Selected);
        }
        public static object GetSelectedItem(Selector Ic)
        {
            if (Ic.Dispatcher.CheckAccess()) return Ic.SelectedItem;
            else return Ic.Dispatcher.Invoke(new Func<Selector, object>(GetSelectedItem), Ic);
        }
        public static int GetSelectedIndex(Selector Ic)
        {
            if (Ic.Dispatcher.CheckAccess()) return Ic.SelectedIndex;
            else return (int)Ic.Dispatcher.Invoke(new Func<Selector, int>(GetSelectedIndex), Ic);
        }
        delegate MessageBoxResult MsgBoxDelegate(Window owner, string text, string caption, MessageBoxButton button, MessageBoxImage icon);
        public static MessageBoxResult MsgBox(Window owner, string text, string caption, MessageBoxButton button, MessageBoxImage icon)
        {
            if (owner.Dispatcher.CheckAccess()) return MessageBox.Show(owner, text, caption, button, icon);
            else return (MessageBoxResult)owner.Dispatcher.Invoke(new MsgBoxDelegate(MsgBox), owner, text, caption, button, icon);
        }
        public static double GetRangeValue(RangeBase RngBse)
        {
            if (RngBse.Dispatcher.CheckAccess()) return RngBse.Value;
            else return (double)RngBse.Dispatcher.Invoke(new Func<RangeBase, double>(GetRangeValue), RngBse);
        }
        public static void SetRangeValue(RangeBase RngBse, double V)
        {
            if (RngBse.Dispatcher.CheckAccess()) RngBse.Value = V;
            else RngBse.Dispatcher.Invoke(new Action<RangeBase, double>(SetRangeValue), RngBse, V);
        }
    } // END CLASS: SafeGuiWpf
