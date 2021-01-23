	var calendarServiceStub = new Mock<ICalenderService>();
			
	calendarServiceStub
		.Setup(c => c.Adjust(It.IsAny<DateTime>(), It.IsAny<BusinessDayConvention>(), It.IsAny<List<HolidayCity>>()))
		.Returns(theDateTimeResultYouWant);
