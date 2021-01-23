        [__DynamicallyInvokable]
        public static Encoding UTF8
        {
          [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries"), __DynamicallyInvokable] get
          {
            if (Encoding.utf8Encoding == null)
              Encoding.utf8Encoding = (Encoding) new UTF8Encoding(true);
            return Encoding.utf8Encoding;
          }
        }
