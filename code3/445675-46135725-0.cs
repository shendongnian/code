    public static void Run(Control form, RenderCallback renderCallback, bool useApplicationDoEvents = false)
    {
        if (form == null)
            throw new ArgumentNullException("form");
        if (renderCallback == null)
            throw new ArgumentNullException("renderCallback");
        form.Show();
        using (var renderLoop = new RenderLoop(form) { UseApplicationDoEvents = useApplicationDoEvents })
            while (renderLoop.NextFrame())
                renderCallback();
    }
