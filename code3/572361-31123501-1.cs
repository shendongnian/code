        public override string Publisher
        {
            get { return GetTextAsString(FrameType.TPUB); }
            set { SetTextFrame(FrameType.TPUB, value); }
        }
