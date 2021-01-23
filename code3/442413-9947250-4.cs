    class CustSerializer
    {
        public void Serialize(Stream stream, Parent[] parents, int childCount)
        {
            BinaryWriter sw = new BinaryWriter(stream);
            foreach (var parent in parents)
            {
                sw.Write(parent.id);
                sw.Write(parent.field1);
                sw.Write(parent.field2);
                foreach (var child in parent.children)
                {
                    sw.Write(child.myField);
                    sw.Write(child.X);
                    sw.Write(child.Y);
                }
            }
        }
        public Parent[] Deserialize(Stream stream, int parentCount, int childCount)
        {
            BinaryReader br = new BinaryReader(stream);
            Parent[] parents = new Parent[parentCount];
            for (int i = 0; i < parentCount; i++)
            {
                var parent = new Parent();
                parent.id = br.ReadInt32();
                parent.field1 = br.ReadInt32();
                parent.field2 = br.ReadInt32();
                parent.children = new Child[childCount];
                for (int j = 0; j < childCount; j++)
                {
                    var child = new Child();
                    child.myField = br.ReadInt32();
                    child.X = br.ReadSingle();
                    child.Y = br.ReadSingle();
                    parent.children[j] = child;
                }
                parents[i] = parent;
            }
            return parents;
        }
    }
