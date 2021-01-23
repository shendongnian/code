    public class Dog
    {
        /// <summary>
        /// The unique ID of this dog, aka the number printed on the dog's implanted microchip.
        /// </summary>
        [Key]
        public int Id { get; set; }
        public DateTime Birthday { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// The embarassing number of homeworks shredded.
        /// </summary>
        public long ShreddedHomeworks { get; set; }
    }
          
