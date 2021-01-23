    public class CustomSizing:BuilderExtension, IPlugin {
        public CustomSizing() { }
        public IPlugin Install(Configuration.Config c) {
            c.Plugins.add_plugin(this);
            return this;
        }
        public bool Uninstall(Configuration.Config c) {
            c.Plugins.remove_plugin(this);
            return true;
        }
        //Executes right after the bitmap has been loaded and rotated/paged
        protected override RequestedAction PostPrepareSourceBitmap(ImageState s) {
            //I suggest only activating this logic if you get a particular querystring command.
            if (!"true".Equals(s.settings["customsizing"], 
                StringComparison.OrdinalIgnoreCase)) return RequestedAction.None;
            //s.sourceBitmap.HorizontalResolution
            //s.sourceBitmap.VerticalResolution
            //Set output pixel dimensions and fit mode
            //s.settings.Width = X;
            //s.settings.Height = Y;
            //s.settings.Mode = FitMode.Max;
            //Set output res.
            //s.settings["dpi"] = "96";
            return RequestedAction.None;
        }
     }
