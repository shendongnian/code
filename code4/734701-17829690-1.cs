            consumer.Start();
            for (int i = 0; i < itemCount; i++)
            {
                consumer.Enqueue(i);
            }
            consumer.StopAdding();
