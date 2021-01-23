        private void Load()
        {
            slideListView.Items.Clear();
            List<SlideItems> listProjectContents = DeSerializeObjects();
            if (listProjectContents != null)
            {
                int loadCount = 0;
                foreach (SlideItems slide in listProjectContents)
                {
                    BitmapSource bSource = Base64ToImage(slide.slidePreview);
                    var item = new MyItem { Text = (loadCount++).ToString(), Image = bSource };
                    slideListView.Items.Add(item);
                }
            }
        }
