    @Transactional
    @Override
    public PendingOrder placeOrder(Address deliveryAddress, Date deliveryTime) {
        PendingOrder pendingOrder = pendingOrderFactory.placeOrderWith(
				deliveryAddress, deliveryTime);//refactor to factory
        pendingOrderRepository.store(pendingOrder);
        return pendingOrder;
    }
