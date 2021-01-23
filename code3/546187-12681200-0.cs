    [XmlRoot("listing-confirmation")]
    public class Listing_confirmation
    {
        [XmlElement("account-id")]
        public int account_id { get; set; }
        [XmlElement("allow-bid")]
        public bool allow_bid { get; set; }
        [XmlElement("allow-both")]
        public bool allow_both { get; set; }
        [XmlElement("allow-buy")]
        public bool allow_buy { get; set; }
        [XmlElement("allow-offers")]
        public bool allow_offers { get; set; }
        [XmlElement("auction-work-order")]
        public int auction_work_order { get; set; }
        [XmlElement("bid-count")]
        public int bid_count { get; set; }
        [XmlElement("bid-increment")]
        public int bid_increment { get; set; }
        [XmlElement("buyer-group-name")]
        public string buyer_group_name { get; set; }
        [XmlElement("buyer-group-type")]
        public string buyer_group_type { get; set; }
        [XmlElement("buy-now-price")]
        public int buy_now_price { get; set; }
        [XmlElement("condition-report-url")]
        public string condition_report_url { get; set; }
        [XmlElement("current-bid")]
        public int current_bid { get; set; }
        //[XmlElement("end-timestamp")]
        //public DateTime end_timestamp { get; set; }
        [XmlElement("event-sale-id")]
        public int event_sale_id { get; set; }
        [XmlElement("event-sale-name")]
        public string event_sale_name { get; set; }
        [XmlElement("facilitated-auction-code")]
        public string facilitated_auction_code { get; set; }
        [XmlElement("floor-price")]
        public int floor_price { get; set; }
        //[XmlElement("listing-activated-timestamp")]
        //public DateTime listing_activated_timestamp { get; set; }
        [XmlElement("manheim-group-code")]
        public string manheim_group_code { get; set; }
        //[XmlElement("message-triggered")]
        //public DateTime message_triggered { get; set; }
        [XmlElement("physical-location")]
        public string physical_location { get; set; }
        [XmlElement("seller-id")]
        public int seller_id { get; set; }
        [XmlElement("starting-bid-price")]
        public int starting_bid_price { get; set; }
        //[XmlElement("start-timestamp")]
        //public DateTime start_timestamp { get; set; }
        [XmlElement("stock-number")]
        public string stock_number { get; set; }
        [XmlElement("unique-bidder-count")]
        public int unique_bidder_count { get; set; }
        [XmlElement("vehicle-detail-url")]
        public string vehicle_detail_url { get; set; }
        [XmlElement("view-count")]
        public int view_count { get; set; }
        [XmlElement("vin")]
        public string vin { get; set; }
    }
