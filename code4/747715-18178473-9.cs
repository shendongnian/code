    @Test
    public void placesAPendingOrder() throws Exception {
        final PendingOrder pendingOrder = new PendingOrderFixture().build();
        final Address deliveryAddress = pendingOrder.getDeliveryAddress();
        final Date deliveryTime = pendingOrder.getDeliveryTime();
        context.checking(new Expectations() {
	   {
                allowing(pendingOrderFactory).placeOrderWith(deliveryAddress,
						deliveryTime);//need to implement equals
                will(returnValue(pendingOrder));
                oneOf(pendingOrderRepository).store(pendingOrder);//need to implement equals
            }
        });
        PendingOrder order = target.placeOrder(deliveryAddress, deliveryTime);
        assertThat(order, is(pendingOrder));
    }
