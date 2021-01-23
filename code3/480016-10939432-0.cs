            #region save allowance
            IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication();
            //Open existing file
            using (var writer = new StreamWriter(myIsolatedStorage.OpenFile("foo.txt", FileMode.Truncate, FileAccess.Write)))
            {
                writer.Write(App.ViewModel.Foo);
            }
            #endregion
            #region save log
            using (var writer = new StreamWriter(myIsolatedStorage.OpenFile("log.txt", FileMode.Truncate, FileAccess.Write)))
            {
                foreach( var i in App.ViewModel.Items )
                    writer.Write(i.ToString());
            }
            #endregion
