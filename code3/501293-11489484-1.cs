        public void Save(string path , bool Locked , PictureBox pb) 
        { 
            string fn; 
            string t = Path.GetFileNameWithoutExtension(wo_name); 
            if (File.Exists(path + "\\" + "DATABASE" + "\\" + t + "\\" + wo_name)) 
            { 
                string f = Path.Combine(path + "\\" + "DATABASE" + "\\" + t + "\\" + wo_name); 
                File.Delete(f); 
 
                fn = path + "\\" + "DATABASE" + "\\" + t + "\\" + wo_name; 
            } 
            else 
            { 
                fn = path + "\\" + "DATABASE" + "\\" + wo_name + "\\" + wo_name + ".txt"; 
            } 
            OptionsFile setting_file = null;
            try
            {
                setting_file = new OptionsFile(fn);
                setting_file.SetKey("File Name", fn); 
                setting_file.SetKey("Version", version); 
                setting_file.SetKey("Button Lock", Locked.ToString()); 
 
                setting_file.SetKey("picturebox.Width", pb.Width.ToString()); 
                setting_file.SetKey("picturebox.Height", pb.Height.ToString()); 
                setting_file.SetListFloatKey("Coordinates_X", woc.Point_X); 
                setting_file.SetListFloatKey("Coordinates_Y", woc.Point_Y); 
 
                setting_file.SetListIntKey("ConnectionStart", connectionStart); 
                setting_file.SetListIntKey("ConnectionEnd", connectionEnd); 
            }
            finally
            {
                if (setting_file != null)
                    setting_file.Close();
            }
        } 
 
        public void Load( string path) 
        { 
            string fn = path + "\\" + wo_name;  
          
            OptionsFile setting_file = null;
            try
            {
                setting_file = new OptionsFile(fn);
                woc.Point_X = new List<float>(); 
                woc.Point_Y = new List<float>(); 
 
                woc.Point_X = setting_file.GetListFloatKey("Coordinates_X"); 
                woc.Point_Y = setting_file.GetListFloatKey("Coordinates_Y"); 
 
 
                connectionStart = new List<int>(); 
                connectionEnd = new List<int>(); 
 
                connectionStart = setting_file.GetListIntKey("ConnectionStart"); 
                connectionEnd = setting_file.GetListIntKey("ConnectionEnd"); 
 
                lockObject = setting_file.GetKey("Button Lock"); 
            }
            finally
            {
                if (setting_file != null)
                    setting_file.Close();
            }
        } 
