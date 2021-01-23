    class NotesWaveProvider : WaveProvider32
    {
        public NotesWaveProvider(Queue<Note> notes)
        {
            this.Notes = notes;
        }
        public readonly Queue<Note> Notes;
        int sample = 0;
        Note NextNote()
        {
            for (; ; )
            {
                if (Notes.Count == 0)
                    return null;
                var note = Notes.Peek();
                if (sample < note.Duration.TotalSeconds * WaveFormat.SampleRate)
                    return note;
                Notes.Dequeue();
                sample = 0;
            }
        }
        public override int Read(float[] buffer, int offset, int sampleCount)
        {
            int sampleRate = WaveFormat.SampleRate;
            for (int n = 0; n < sampleCount; n++)
            {
                var note = NextNote();
                if (note == null)
                    buffer[n + offset] = 0;
                else
                    buffer[n + offset] = (float)(note.Amplitude * Math.Sin((2 * Math.PI * sample * note.Frequency) / sampleRate));
                sample++;
            }
            return sampleCount;
        }
    }
    class Note
    {
        public float Frequency;
        public float Amplitude = 1.0f;
        public TimeSpan Duration = TimeSpan.FromMilliseconds(50);
    }
