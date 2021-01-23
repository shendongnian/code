    class Program
    {
        static object last_item;
        static void Main(string[] args)
        {
            BindingList<object> WorkoutScheduleList = new BindingList<object>();
            WorkoutScheduleList.ListChanged += (s, e) => {
                if (e.ListChangedType == ListChangedType.ItemAdded)
                    last_item = WorkoutScheduleList[e.NewIndex];
            };
            WorkoutScheduleList.Add("Foo");
            WorkoutScheduleList.Add("Bar");
            WorkoutScheduleList.Insert(1, "FooBar");
            //prints FooBar
            Console.WriteLine(String.Format("last item added: {0}", last_item));
        }
    }
