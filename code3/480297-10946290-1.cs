    [DataContract]
    public class LibraryBook
    {
        [DataMember(Name = "ReturnDate")]
        // This can be private because it's only ever accessed by the serialiser.
        private string FormattedReturnDate { get; set; }
        // This attribute prevents the ReturnDate property from being serialised.
        [IgnoreDataMember]
        // This property is used by your code.
        public DateTime ReturnDate
        {
            // Replace "o" with whichever DateTime format specifier you need.
            get { return DateTime.ParseExact(FormattedReturnDate, "o", CultureInfo.InvariantCulture);
            set { FormattedReturnDate = value.ToString("o");
        }
    }
