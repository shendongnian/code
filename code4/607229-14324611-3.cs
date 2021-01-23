    public static class DocLibExtensions {
        public static void Traverse(this DocLib lib,Action<DocLib> process) {
            foreach (var item in lib.Items) {
                process(item);
                item.Traverse(process);
            }
        }
    }
    class Program {
        static void Main(string[] args) {
            DocLib rootDoc = new DocLib {Title = "root"};
            rootDoc.Items.Add( new DocLib{ Title = "c1" });
            rootDoc.Items.Add(new DocLib { Title = "c2" });
            DocLib child = new DocLib {Title = "c3"};
            child.Items.Add(new DocLib {Title = "c3.1"});
            rootDoc.Items.Add(child);
            rootDoc.Traverse(i => Console.WriteLine(i.Title));
        }
    }
