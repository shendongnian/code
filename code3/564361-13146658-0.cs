	class BadEOLStreamReader : StreamReader {
		private int pushback = -1;
		public BadEOLStreamReader(string file, Encoding encoding) : base(file, encoding) {
		}
		public override int Peek() {
			if (pushback != -1) {
				var r = pushback;
				pushback = -1;
				return pushback;
			}
			return base.Peek();
		}
		public override int Read() {
			if (pushback != -1) {
				var r = pushback;
				pushback = -1;
				return pushback;
			}
			skip:
			var ret = base.Read();
			if (ret == 13) {
				var ret2 = base.Read();
				if (ret2 == 10) {
					//it's good, push back the 10
					pushback = ret2;
					return ret;
				}
				//skip it
				goto skip;
			} else if (ret == 10) {
				//skip it
				goto skip;
			} else {
				return ret;
			}
		}
	}
