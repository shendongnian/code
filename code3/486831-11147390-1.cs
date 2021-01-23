        public sealed override void WriteString(string value)
        {
            if (Depth == 0)
            {
                WriteStartArray(); WriteString(value); WriteEndArray();
            }
            else
            {
                EnsureMemberOnObjectBracket();
                WriteStringImpl(value);
                OnValueWritten();
            }
        }
