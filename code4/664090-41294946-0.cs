     static class ControlExtensions
    {
        using System;
        using System.Reflection;
        using System.Windows.Forms;
        static BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic;
        static Type[] SendMessageSig = new Type[] { typeof(int), typeof(int), typeof(int) };
        internal static IntPtr SendMessage(this Control control, int msg, int wparam, int lparam)
        {
            MethodInfo MethodInfo = control.GetType().GetMethod("SendMessage", flags, null, SendMessageSig, null);
            return (IntPtr)MethodInfo.Invoke(control, new object[] { msg, wparam, lparam });
        }
    }
