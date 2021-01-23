        Queue<Note> queue = new Queue<Note>();
        void onClick()
        {
            queue.Enqueue(note);
        }
        void Play()
        {
            if (Playing == true) { return; }
            while (queue.Peek() != null)
            {
                var note = queue.Dequeue();
                note.play();
            }
        }
