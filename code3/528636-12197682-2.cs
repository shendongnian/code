    class MyListRenderer : IObjectRenderer
    {
        public void RenderObject(RendererMap rendererMap, object obj, TextWriter writer)
        {
            var myList = obj as IList<MyClass>;
            if (myList != null) {
                try
                {
                    int no = 1;
                    foreach (MyClass entry in myList)
                    {
                        writer.Write("Entry {0}: PropertyA={1} PropertyB={2}\n",
                                no++,
                                entry.PropertyA,
                                entry.PropertyB);
                    }
                }
                catch (NullReferenceException ex)
                {
                    writer.Write(SystemInfo.NullText);
                }
            }
            else
            {
                new DefaultRenderer().RenderObject(rendererMap, obj, writer);
            }
        }
    }
