	class QueueReader<T> : ContentTypeReader<Queue<T>>
	{
		public override bool CanDeserializeIntoExistingObject { get { return true; } }
		protected override Queue<T> Read(ContentReader input, Queue<T> existingInstance)
		{
			int count = input.ReadInt32();
			Queue<T> queue = existingInstance ?? new Queue<T>(count);
			for(int i = 0; i < count; i++)
				queue.Enqueue(input.ReadObject<T>());
			return queue;
		}
	}
	[ContentTypeWriter]
	class QueueWriter<T> : ContentTypeWriter<Queue<T>>
	{
		public override string GetRuntimeReader(TargetPlatform targetPlatform)
		{
			return typeof(QueueReader<T>).AssemblyQualifiedName;
		}
		public override bool CanDeserializeIntoExistingObject { get { return true; } }
		protected override void Write(ContentWriter output, Queue<T> value)
		{
			output.Write(value.Count);
			foreach(var item in value)
				output.WriteObject<T>(item);
		}
	}
