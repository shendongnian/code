                Wall w = new Wall();
                Ceiling c = new Ceiling();
                Room r = new Room();
                r.MakeElement(w);
                r.MakeElement(c);
                List<Element> NewElements = new List<Element>{ new Wall(), new Ceiling() };
                r.MakeElements(NewElements);
                //r.MakeWalls(5);
                //r.MakeCeilings(6);
                r.AddRoom();
                foreach (Room room in r.GetAllRooms())
                {
                    MessageBox.Show(room.ToString());
                    foreach (Element el in room.RoomElements)
                    {
                        MessageBox.Show(el.ToString());
                    }
                }
