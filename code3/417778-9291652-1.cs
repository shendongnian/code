                Monitor.Enter(BufferCells);
                for (int i = 0; i < BufferCells.Length - 1; i++)
                {
                    if (BufferCells[i].Id != "-1")
                    {
                        value = BufferCells[i];
                        BufferCells[i] = new OrderObject() { Id = "-1" }; /*Clear Cell*/
                        Console.WriteLine(String.Format("        Server Consumed {0}", value.Id));
                        break;
                    }
                }
            }
            finally
            {
                Monitor.Exit(BufferCells);
                _pool.Release();
            }
            return value;
        }
     }
