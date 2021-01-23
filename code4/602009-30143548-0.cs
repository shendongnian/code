		[Fact]
		public void when_parsing_options_then_can_combine_flags()
		{
			var values = "Singleline | Compiled";
			var options = values.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries)
				.Select(value => (RegexOptions)Enum.Parse(typeof(RegexOptions), value))
				.Aggregate(RegexOptions.None, (current, value) => current |= value);
			Assert.Equal(RegexOptions.Singleline | RegexOptions.Compiled, options);
		}
