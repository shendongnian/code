    public static void ThreadProc(Type formType)
    {
        System.Windows.Forms.Application.Run((Form)Activator.CreateInstance(formType));
    }
    new System.Threading.Thread(() => ThreadProc(typeof(MainForm)))
