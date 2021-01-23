        public static void CopyWithStream(
            [BlobInput("container/in/{name}")] Stream input,
            [BlobOutput("container/out1/{name}")] Stream output
            )
        {
            Debug.Assert(input.CanRead && !input.CanWrite);
            Debug.Assert(!output.CanRead && output.CanWrite);
            input.CopyTo(output);
        }
