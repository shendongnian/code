        public int productid { get; set; }
        public string Size { get; set; }
        /// <summary>
        /// do compare-stuff like if-statement on the size or something else
        /// </summary>
        /// <param name="compareProduct">the product to compare with this</param>
        /// <returns>
        /// 0  if both product-sizes are equal
        /// 1  if compareProduct.Size is larger
        /// -1 if this.Size is larger
        /// </returns>
        public int CompareTo(product compareProduct)
        {
            // TODO: implement
        }
    }
