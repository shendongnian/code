    public static class InterfaceEvents
    {
        public static List<EventData> List = new List<EventData>();
        public static void Resolve()
        {
            while (List.Count > 0)
            {
                for (int i = List.Count - 1; i > 0; i--)
                {
                    if (List[i].EventType == List[0].EventType)
                    {
                        if (List[i].Sender.Layer < List[0].Layer) // However you choose to manage it.
                        {
                            List[0] = List[i];
                            List.RemoveAt(i);
                        }
                        else
                            List.RemoveAt(i);
                    }
                }
                // Toggle event from List[0]
                List.RemoveAt(0);
            }
        }
    }
    public struct EventData
    {
        public InterfaceComponent Sender;
        public int EventType;
    }
