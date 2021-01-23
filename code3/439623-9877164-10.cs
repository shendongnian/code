    public static void UIMethodCall(object ObjectState)
    {
        String response = ObjectState as String;
        label1.Text = String.Format("Output: {0}", response);
        //Or whatever you need to do in the UI...
    }
