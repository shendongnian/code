            private void YourDataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit && isInsertMode == true)
            {
                var vid = e.Row.DataContext as video;
                
                var context = new YourEntities();
                var Video = new video //video is the class
                {
                    
                    IDVideo = vid.IDVideo,
                    Titlu = vid.Titlu
                };
                context.videos.Add(Video);
                context.SaveChanges();
            }
        }
        private void YourDataGrid_AddingNewItem(object sender, AddingNewItemEventArgs e)
        {
            isInsertMode = true;
        }
